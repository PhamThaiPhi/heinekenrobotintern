﻿using heineken.Data;
using heineken.Models;
using System.Collections.Generic;
using System.Linq;

namespace heineken.Service.RecyclingService
{
    public class RecyclingService : IRecyclingService
    {
        private readonly MyDbHei _context;

        public RecyclingService(MyDbHei context)
        {
            _context = context;
        }

        public List<RecyclingMachine> GetAllRecy()
        {
            return _context.RecyclingMachines.ToList();
        }

        public RecyclingMachine GetRecyById(int id)
        {
            return _context.RecyclingMachines.Find(id);
        }

        public RecyclingMachine CreateRecy(RecyclingModel model)
        {
            var newMachine = new RecyclingMachine
            {
                MachineName = model.MachineName,      
                ActivityLocation = model.ActivityLocation,
                DateAdded = DateTime.Now,
                AccessCount = model.AccessCount,
                LastConnectionTime = DateTime.Now,
                MachineStatus = (RecyclingMachine.Status)model.MachineStatus,
                BinStatus = (RecyclingMachine.FillStatus)model.BinStatus

            };

            _context.RecyclingMachines.Add(newMachine);
            _context.SaveChanges();
            return newMachine;
        }

        public RecyclingMachine UpdateRecy(int id, RecyclingModel model)
        {
            var existingMachine = _context.RecyclingMachines.SingleOrDefault(m => m.MachineID == id);
            if (existingMachine == null)
            {
                throw new KeyNotFoundException("Recycling machine not found!");
            }

            existingMachine.MachineName = model.MachineName;
            existingMachine.MachineStatus = (RecyclingMachine.Status)model.MachineStatus;
            existingMachine.ActivityLocation = model.ActivityLocation;
            existingMachine.AccessCount = model.AccessCount;
            existingMachine.BinStatus = (RecyclingMachine.FillStatus)model.BinStatus;
            existingMachine.LastConnectionTime = DateTime.Now;

            _context.SaveChanges();
            return existingMachine;
        }

        public bool DeleteRecy(int id)
        {
            var machine = _context.RecyclingMachines.Find(id);
            if (machine == null) return false;

            _context.RecyclingMachines.Remove(machine);
            _context.SaveChanges();
            return true;
        }
    }
}