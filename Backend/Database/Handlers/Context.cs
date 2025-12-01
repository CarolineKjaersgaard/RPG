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

            modelBuilder.Entity<Room>().HasMany(l => l.Loot).WithOne(r => r.Room).HasForeignKey(r => r.RoomId);
            modelBuilder.Entity<Room>().HasMany(e => e.Enemies).WithOne(r => r.Room).HasForeignKey(r => r.RoomId);
            modelBuilder.Entity<Item>().HasMany(r => r.Rooms).WithOne(i => i.Item).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<Item>().HasMany(e => e.Enemies).WithOne(i => i.Item).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<Enemy>().HasMany(r => r.Rooms).WithOne(e => e.Enemy).HasForeignKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().HasMany(l => l.Loot).WithOne(e => e.Enemy).HasForeignKey(e => e.EnemyId);
            modelBuilder.Entity<Effect>().HasMany(r => r.Rooms).WithOne(e => e.Effect).HasForeignKey(e => e.EffectId);
            modelBuilder.Entity<Effect>().HasMany(i => i.Items).WithOne(e => e.Effect).HasForeignKey(e => e.EffectId);
            modelBuilder.Entity<Effect>().HasMany(e => e.Enemies).WithOne(e => e.Effect).HasForeignKey(e => e.EffectId);
            modelBuilder.Entity<RoomType>().HasMany(r => r.Rooms).WithOne(t => t.Type).HasForeignKey(t => t.TypeId);
            modelBuilder.Entity<ItemType>().HasMany(i => i.Items).WithOne(t => t.Type).HasForeignKey(t => t.TypeId);
            modelBuilder.Entity<EnemyType>().HasMany(e => e.Enemies).WithOne(t => t.Type).HasForeignKey(t => t.TypeId);
            modelBuilder.Entity<EffectType>().HasMany(e => e.Effects).WithOne(t => t.Type).HasForeignKey(t => t.TypeId);
            modelBuilder.Entity<TargetType>().HasMany(e => e.EffectTypes).WithOne(t => t.TargetType).HasForeignKey(t => t.TargetTypeId);
        }
    }
}