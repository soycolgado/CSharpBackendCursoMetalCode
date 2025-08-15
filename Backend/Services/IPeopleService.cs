namespace Backend.Services;

using Controllers;

public interface IPeopleService
{
    bool Validate(People people);
}