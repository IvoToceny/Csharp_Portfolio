﻿using MarketCarsLibrary.Models;

namespace MarketCarsLibrary.Data.Interfaces
{
    public interface ICarsData
    {
        Task<CarsModel> Create(CarsModel carsModel);
        Task<int> DeleteById(int id);
        Task<List<CarsModel>> GetAll();
        Task<List<CarsModel>> GetAllByUserId(int id);
        Task<CarsModel> GetAllByUserAndCarId(int userId, int carId);
        Task<CarsModel> UpdateById(CarsModel carsModel);
    }
}