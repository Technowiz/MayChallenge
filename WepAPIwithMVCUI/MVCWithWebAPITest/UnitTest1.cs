using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCwithWebAPI.Controllers;
using MVCwithWebAPI.Models;

namespace MVCWithWebAPITest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        Employee emp1 = null;
        Employee emp2 = null;
        List<Employee> emps = null;
        EmployeesController controller = null;

        public EmployeeControllerTest()
        {
            // Lets create some sample books
            emp1 = new Employee { Name = "Tony", Address = "Chennai", Gender = "Female", Company = "NA", Designation = "NA" };
            emp2 = new Employee { Name = "John", Address = "NA", Gender = "Male", Company = "NA", Designation = "NA" };

            emps = new List<Employee>
            {
                emp1,
                emp2,
            };
            controller = new EmployeesController();
        }
        [TestMethod]
        public void Create()
        {
            // Lets create a valid book objct to add into
            Employee newEmp = new Employee { Name = "new", Address = "new", Gender = "NA" ,Company="NA",Designation="NA"};

            // Lets call the action method now
            controller.Create(newEmp);

            // get the list of books
            List<Employee> emps = 

            CollectionAssert.Contains(emps, newEmp);
        }

        [TestMethod]
        public void Edit()
        {
            // Lets create a valid book objct to add into
            Book editedBook = new Book { ID = 1, BookName = "new", AuthorName = "new", ISBN = "NA" };

            // Lets call the action method now
            controller.Edit(editedBook);

            // get the list of books
            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.Contains(books, editedBook);
        }

        [TestMethod]
        public void Delete()
        {
            // Lets call the action method now
            controller.Delete(1);

            // get the list of books
            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.DoesNotContain(books, book1);
        }
    }
}
