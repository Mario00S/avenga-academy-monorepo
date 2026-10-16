using MapsterMapper;
using PizzaApp.DataAccess.Repositories.Abstractions;
using PizzaApp.Domain.Entities;
using PizzaApp.Dtos.Pizzas;
using PizzaApp.Services.Abstractions;
using PizzaApp.Services.Extensions;
using PizzaApp.Shared.Exceptions;

namespace PizzaApp.Services.Implementations;

public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _pizzaRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public PizzaService(
        IPizzaRepository pizzaRepository,
        IMapper mapper,
        ICurrentUser currentUser)
    {
        _pizzaRepository = pizzaRepository;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    public async Task<List<PizzaDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        string? userId = _currentUser.IsAdmin ? null : _currentUser.Id;

        List<Pizza> pizzas = await _pizzaRepository.GetSavedPizzasAsync(userId, cancellationToken);

        return _mapper.Map<List<PizzaDto>>(pizzas);
    }

    public async Task<PizzaDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var pizza = await FindPizzaAsync(id, cancellationToken);
        _currentUser.EnsureOwnerOrAdmin(pizza.UserId);

        return _mapper.Map<PizzaDto>(pizza);
    }

    public async Task<PizzaDto> CreateAsync(AddPizzaDto request, CancellationToken cancellationToken = default)
    {
        var pizza = _mapper.Map<Pizza>(request);
        pizza.UserId = _currentUser.Id;

        await _pizzaRepository.AddAsync(pizza, cancellationToken);

        return _mapper.Map<PizzaDto>(pizza);
    }

    public async Task<PizzaDto> UpdateAsync(int id, UpdatePizzaDto request, CancellationToken cancellationToken = default)
    {
        var pizza = await FindEditablePizzaAsync(id, cancellationToken);

        _mapper.Map(request, pizza);
        pizza.UpdatedDate = DateTime.UtcNow;

        await _pizzaRepository.UpdateAsync(pizza, cancellationToken);

        return _mapper.Map<PizzaDto>(pizza);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var pizza = await FindEditablePizzaAsync(id, cancellationToken);
        await _pizzaRepository.DeleteAsync(pizza, cancellationToken);
    }

    private async Task<Pizza> FindPizzaAsync(int id, CancellationToken cancellationToken)
    {
        return await _pizzaRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException(nameof(Pizza), id);
    }

    private async Task<Pizza> FindEditablePizzaAsync(int id, CancellationToken cancellationToken)
    {
        var pizza = await FindPizzaAsync(id, cancellationToken);
        _currentUser.EnsureOwnerOrAdmin(pizza.UserId);

        if (pizza.OrderId is not null)
        {
            throw new ConflictException("This pizza is part of an order and can't be changed anymore.");
        }

        return pizza;
    }
}
