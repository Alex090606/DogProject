﻿using DogsApp.Infrastructure.Data.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogApp.Core.Contracts
{
    public interface IDogService
    {

        bool Create(string name, int age, string breed, string picture);
        bool UpdateDog(int dogId, string name, int age, string breed, string picture);
        List<Dog> GetDogs();
        Dog GetDogById(int dogId);
        bool RemoveById(int dogId);
        List<Dog> GetDogs(string searchStringBreed, string searchStringName);
    }
}
