using Mapster;
using PizzaApp.Domain.Entities;
using PizzaApp.Dtos.Users;

namespace PizzaApp.Mappers.Configurations;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>()
            .Ignore(ignore => ignore.Roles);
        //this is for custom exception or 
            //.Map(u => u.Roles, src => "")
    }
}
