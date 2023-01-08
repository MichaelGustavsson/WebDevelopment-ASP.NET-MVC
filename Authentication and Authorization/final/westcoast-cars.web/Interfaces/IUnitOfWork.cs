namespace westcoast_cars.web.Interfaces;

public interface IUnitOfWork
{
    IVehicleRepository VehicleRepository { get; }
    Task<bool> Complete();
}
