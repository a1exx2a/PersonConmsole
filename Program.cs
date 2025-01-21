﻿using System.ComponentModel;
using System.IO.Pipelines;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;
using Microsoft.VisualBasic;

public class Employee //работник
{
    public string Id {get;set;} //айдишка
    public string Name {get;set;} //имя
    public string Department {get;set;} //место работы
    public string Position {get;set;} //позиция на работе

    public Employee(string name, string id, string department, string position)
    {
        Id = id;
        Name = name;
        Department = department;
        Position = position;
    }
}

// Класс для работы с данными
public class Employees //работники
{

    private List<Employee> _listEmployees;

    public Employees(List<Employee> listEmployees)
    {
        _listEmployees = listEmployees;
    }

    
    public Employee FindEmployeeById(string id)
    {
        foreach (Employee person in _listEmployees)
        {
            if (person.Id == id){
                return person;
            }
        }
        return null;

    }
    
    public void AddEmployee(Employee employee)
    {

        _listEmployees.AddRange(employee);
        Console.WriteLine("Данные нового пользователя успешно записаны!");
    }
    
    public void UpdateEmployee(Employee employee)
    {

    }
    
    public void RemoveEmployee(string id)
    {

    }
}



public class Program
{   
    public static void Main()
    {    
        Employee employee1 = new Employee("Сьюзан Майерс","1","Бухгалтерия","Вице-президент");
        Employee employee2 = new Employee("Боб","2","Офис","Работник");
        Employee employee3 = new Employee("Иван","3","Охрана","Охраник");


        List<Employee> employees = new List<Employee> {employee1, employee2, employee3};

        Console.WriteLine("1. Найти сотрудника по идентификационному номеру");
        Console.WriteLine("2. Добавить нового сотрудника");
        Console.WriteLine("3. Изменить имя, отдел и должность существующего сотрудника");
        Console.WriteLine("4. Удалить сотрудника");
        Console.WriteLine("0. Выйти из программы");


        Employees emploeesList = new Employees(employees);
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("\nВведите номер нужного действия в системе: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите id сотрудника: ");
                    var id = Console.ReadLine();
                    var found_person = emploeesList.FindEmployeeById(id);
                    if (found_person != null){
                        Console.WriteLine($"ID --> {found_person.Id}, Имя --> {found_person.Name}, Место работы --> {found_person.Department}, Позиция --> {found_person.Position}");
                    }
                    else{
                        Console.WriteLine($"Пользователь с ID {id} не найден.");
                    }
                    break;



                case "2":
                    
                    Console.WriteLine("Введите имя нового пользователя: ");
                    var new_name = Console.ReadLine();
                    Console.WriteLine("Введите ID(уникальный индификатор) нового пользователя: ");
                    var new_id = Console.ReadLine(); 
                    Console.WriteLine("Введите место работы нового пользователя: ");
                    var new_department = Console.ReadLine();
                    Console.WriteLine("Введите позицию на месте работы нового пользователя: ");
                    var new_position = Console.ReadLine();

                    Employee add_person = new Employee(new_name,new_id,new_department,new_position);
                    emploeesList.AddEmployee(add_person);


                    break;
                case "3":
                    Console.WriteLine("Я похож на программиста? Жди!");
                    break;
                case "4":
                    Console.WriteLine("Я похож на программиста? Жди!");
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Неверное значение");
                    break;
            }
        }
    }
}