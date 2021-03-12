using FluentApiLessons.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLessons.Data
{
    public class DishesContext : DbContext
    {
        public DishesContext()
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-6543DI3; Database = FluentApiLesson; Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // обратись к сущности продукт и что-то сделай
            modelBuilder.Entity<Product>()
                .ToTable("products") // задаем название таблицы
                .Property(product => product.Id)
                .HasColumnName("ID");//задаем имя столбцу

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Product>()
                .Property(product => product.Name)
                .HasColumnName("name")//задаем имя столбцу
                .HasMaxLength(50) // максимальную длину
                .IsRequired(); // not null

            /*modelBuilder.Entity<Product>()
                .Property(product => product.DishId)
                .HasColumnName("dishId");//задаем имя столбцу*/

            modelBuilder.Entity<Dish>()
                .HasMany(dish => dish.Products)
                .WithMany(product => product.Dishes)
                .UsingEntity(j => j.ToTable("DishProducts"));


                /*.HasOne(product => product.Dish)
                .WithMany(dish => dish.Products);*/



            modelBuilder.Entity<Dish>()
                .ToTable("dishes")
                .Property(dish => dish.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Dish>()
                .HasKey(dish => dish.Id);

            modelBuilder.Entity<Dish>()
                .Property(dish => dish.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}
