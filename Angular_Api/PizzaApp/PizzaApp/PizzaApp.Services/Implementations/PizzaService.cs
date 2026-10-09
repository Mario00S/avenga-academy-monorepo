using MapsterMapper;
using PizzaApp.DataAccess.Repositories.Abstractions;
using PizzaApp.Domain.Entities;
using PizzaApp.Dtos.Pizzas;
using PizzaApp.Services.Abstractions;
using PizzaApp.Shared.Exceptions;

namespace PizzaApp.Services.Implementations;

public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _pizzaRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;
    public PizzaService(IPizzaRepository pizzaRepository, IMapper mapper)
    {
        _pizzaRepository = pizzaRepository;
        _mapper = mapper;
    }
    public async Task<List<PizzaDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        string? userId = _currentUser.IsAdmin ? null : _currentUser.Id;

        List<Pizza> pizzas = await _pizzaRepository.GetSavedPizzasAsync(userId, cancellationToken);

        List<PizzaDto> result = _mapper.Map<List<PizzaDto>>(pizzas);

        return result;
    }
    public async Task<PizzaDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
               
        var pizza = await FindPizzaAsync(id, cancellationToken);

        if (!_currentUser.IsAdmin && _currentUser.Id != pizza.UserId)
        {
            throw new ForbiddenException("You are not authorized to access this pizza");
        }

        return _mapper.Map<PizzaDto>(pizza);
    }
    public Task<PizzaDto> CreateAsync(AddPizzaDto request, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<PizzaDto> UpdateAsync(int id, AddPizzaDto request, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task DeleteAsync(int id, AddPizzaDto request, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    private async Task<Pizza> FindPizzaAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _pizzaRepository.GetByIdAsync(id, cancellationToken)
        ?? throw new NotFoundException($"Pizza with id {id} not found");
    }
}
