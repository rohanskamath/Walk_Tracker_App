﻿using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.DifficultyRepository
{
    public class DifficultyImplementation : IDifficultyRepository
    {
        private readonly DBContext dBContext;
        public DifficultyImplementation(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Difficulty> CreateDifficulty(Difficulty difficulty)
        {
            await dBContext.Difficulties.AddAsync(difficulty);
            await dBContext.SaveChangesAsync();
            return difficulty;
        }

        public async Task<List<Difficulty>> GetAllDifficulies()
        {
            return await dBContext.Difficulties.ToListAsync();
        }

        public async Task<Difficulty> UpdateDifficulty(int id, Difficulty difficulty)
        {
            var existingDifficulty = await dBContext.Difficulties.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDifficulty == null)
            {
                return null;
            }
            existingDifficulty.Name = difficulty.Name;
            await dBContext.SaveChangesAsync();
            return existingDifficulty;
        }
    }
}
