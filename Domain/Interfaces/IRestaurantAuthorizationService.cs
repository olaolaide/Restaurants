﻿using Domain.Constants;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IRestaurantAuthorizationService
{
    bool Authorize(Restaurant restaurant, ResourceOperations resourceOperations);
}