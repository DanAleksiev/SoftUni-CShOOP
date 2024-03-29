﻿namespace PersonsInfo
    {
    public class Person
        {
        public Person(string firstName, string lastName, int age, decimal salary)
            {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
            }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

        public void IncreaseSalary(decimal increse)
            {
            if (this.Age < 30)
                {
                increse /= 200;
                }
            else
                {
                increse /= 100;
                }

            this.Salary += this.Salary * increse;
            }
        public override string ToString()
            {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva."; ;
            }
        }
    }
