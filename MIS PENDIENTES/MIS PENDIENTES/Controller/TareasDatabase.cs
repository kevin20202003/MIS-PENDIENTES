﻿using MIS_PENDIENTES.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MIS_PENDIENTES.Controller
{
    public class TareasDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public TareasDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Tarea>().Wait();
        }

        public Task<List<Tarea>> GetTareasAsync()
        {
            return _database.Table<Tarea>().ToListAsync();
        }

        public Task<Tarea> GetTareaAsync(int id)
        {
            return _database.Table<Tarea>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTareaAsync(Tarea tarea)
        {
            if (tarea.Id != 0)
            {
                return _database.UpdateAsync(tarea);
            }
            else
            {
                return _database.InsertAsync(tarea);
            }
        }

        public Task<int> DeleteTareaAsync(Tarea tarea)
        {
            return _database.DeleteAsync(tarea);
        }
    }
}
