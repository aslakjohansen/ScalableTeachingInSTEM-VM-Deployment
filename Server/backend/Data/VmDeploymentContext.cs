﻿using Microsoft.EntityFrameworkCore;
using ScalableTeaching.Models;

namespace ScalableTeaching.Data
{
    public class VmDeploymentContext : DbContext
    {
        public VmDeploymentContext(DbContextOptions<VmDeploymentContext> options) : base(options) { }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineAssignment> MachineAssignments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupAssignment> GroupAssignments { get; set; }
        public DbSet<MachineStatus> MachineStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MachineAssignment>().HasKey(c => new { c.MachineID, c.UserUsername });
            modelBuilder.Entity<GroupAssignment>().HasKey(c => new { c.GroupID, c.UserUsername });
        }
    }
}
