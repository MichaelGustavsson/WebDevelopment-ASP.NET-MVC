namespace westcoast_cars.web.Interfaces;

public interface IUnitOfWork
{
    IVehicleRepository VehicleRepository { get; }
    IUserRepository UserRepository { get; }
    Task<bool> Complete();
}
