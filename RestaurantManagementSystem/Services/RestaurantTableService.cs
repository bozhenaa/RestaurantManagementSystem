using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repositories;

namespace RestaurantManagementSystem.Services


{
    public class RestaurantTableService : IRestaurantTableService
    {
        private readonly IRestaurantTableRepository _restaurantTablerepository;
        public RestaurantTableService(IRestaurantTableRepository restaurantTableRepository)
        {
            _restaurantTablerepository = restaurantTableRepository;
        }
        public async Task AddTable(AddRestaurantTableDto table)
        {
            if (table == null)
            {
                throw new ArgumentNullException();
            }
            if (await _restaurantTablerepository.GetTableByNumber(table.TableNumber) != null)
            {
                throw new InvalidOperationException("Table with the same number already exists.");
            }
            var newTable = new RestaurantTable
            {
                TableNumber = table.TableNumber,
                Seats = table.Seats,
                RoomName = table.RoomName
            };
            await _restaurantTablerepository.AddTable(newTable);
        }

        public async Task DeleteTable(RestaurantTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException();
            }
            if (await _restaurantTablerepository.GetTableByNumber(table.TableNumber) == null)
            {
                throw new InvalidOperationException("Table with the same number does not exists.");
            }
            await _restaurantTablerepository.DeleteTable(table);
        }

        public async Task<IEnumerable<RestaurantTable>> GetAllTables()
        {
            return await _restaurantTablerepository.GetAllTables();
        }

        public async Task<RestaurantTable> GetTableById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var existingTable = await _restaurantTablerepository.GetTableById(id);
            if (existingTable == null)
            {
                throw new ArgumentNullException();
            }
            return existingTable;
        }

        public async Task<RestaurantTable> GetTableByNumber(int tableNumber)
        {
            if (tableNumber < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var existingTable = await _restaurantTablerepository.GetTableByNumber(tableNumber);
            if (existingTable == null)
            {
                throw new ArgumentNullException();
            }
            return existingTable;
        }

        public async Task<IEnumerable<RestaurantTable>> GetTablesByRoom(RoomName roomName)
        {
            var existingTables = await _restaurantTablerepository.GetTablesByRoom(roomName);
            return existingTables;
        }

        public async Task UpdateTable(AddRestaurantTableDto table)
        {
            if (table == null)
            {
                throw new ArgumentNullException();
            }
            var existingTable = await _restaurantTablerepository.GetTableByNumber(table.TableNumber);
            if (existingTable== null)
            {
                throw new InvalidOperationException("Table with the same number does not exists.");
            }
           existingTable.Seats = table.Seats;
           existingTable.RoomName = table.RoomName;
           await _restaurantTablerepository.UpdateTable(existingTable);
        }
    }
}
