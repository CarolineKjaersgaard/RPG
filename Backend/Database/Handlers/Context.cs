using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Tables;

namespace Backend.Database.Handlers
{
    public class Context : DbContext
    {
        public DbSet<Room> Rooms {get; set;}
        public DbSet<Item> Items {get; set;}
        public DbSet<Enemy> Enemies {get; set;}
        public DbSet<Effect> Effects {get; set;}
        public DbSet<RoomType> RoomTypes {get; set;}
        public DbSet<ItemType> ItemTypes {get; set;}
        public DbSet<EnemyType> EnemyTypes {get; set;}
        public DbSet<EffectType> EffectTypes {get; set;}
        public DbSet<TargetType> TargetTypes {get; set;}
        public DbSet<EnemyInRoom> EnemiesInRooms {get; set;}
        public DbSet<LootInRoom> LootInRooms {get; set;}
        public DbSet<LootOnEnemy> LootOnEnemies {get; set;}

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasKey(p => p.Id);
            modelBuilder.Entity<Item>().HasKey(p => p.Id);
            modelBuilder.Entity<Enemy>().HasKey(p => p.Id);
            modelBuilder.Entity<Effect>().HasKey(p => p.Id);
            modelBuilder.Entity<RoomType>().HasKey(p => p.Id);
            modelBuilder.Entity<ItemType>().HasKey(p => p.Id);
            modelBuilder.Entity<EnemyType>().HasKey(p => p.Id);
            modelBuilder.Entity<EffectType>().HasKey(p => p.Id);
            modelBuilder.Entity<TargetType>().HasKey(p => p.Id);
            modelBuilder.Entity<EnemyInRoom>().HasKey(p => p.Id);
            modelBuilder.Entity<LootInRoom>().HasKey(p => p.Id);
            modelBuilder.Entity<LootOnEnemy>().HasKey(p => p.Id);
        }
    }
}