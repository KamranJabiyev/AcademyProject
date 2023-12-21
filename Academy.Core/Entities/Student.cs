﻿using Academy.Core.Interfaces;

namespace Academy.Core.Entities;

public class Student:IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public Group Group { get; set; }
    public bool IsDelete { get; set; }
    private static int _id;
    public Student(string name)
    {
        Id = _id++;
        Name = name;
    }
}