﻿using project_.net.Models;

namespace project_.net.Database
{
    public class ReservationRepository
    {
        Context context = Context.getInstance();

        public void addReservation(int clientId, int restaurantId, DateTime date, int nb)
        {
            ClientRepository clientRepository= new ClientRepository();
            Client client = clientRepository.getClientById(clientId);
            RestaurantRepository restaurantRepository = new RestaurantRepository();
            Restaurant restaurant = restaurantRepository.getRestaurantById(restaurantId);
            Reservation reservation = new Reservation(date, nb);
            reservation.client = client;
            reservation.restaurant = restaurant;
            context.Reservation.Add(reservation);
            context.SaveChanges();
        }
    }
}
