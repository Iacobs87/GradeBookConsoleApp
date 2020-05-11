﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBook.Test
{
    [TestClass]
    public class TypeTest
    {
        [TestMethod]
        [TestCategory("Book Test")]
        public void CSharpCanPassByRef()
        {
            //arange 
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            //act

            //assert
            Assert.AreEqual("New Name", book1.Name);

        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [TestMethod]
        [TestCategory("Book Test")]
        public void CSharpIsPassByValue()
        {
            //arange 
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            //act

            //assert
            Assert.AreEqual("Book 1", book1.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [TestMethod]
        [TestCategory("Book Test")]
        public void CanSetNameFromReference()
        {
            //arange 
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            //act

            //assert
            Assert.AreEqual("New Name", book1.Name);
            
        }

        [TestMethod]
        [TestCategory("Book Test")]
        public void GetBookReturnDifferentObjects()
        {
            //arange 
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act

            //assert
            Assert.AreEqual("Book 1", book1.Name);
            Assert.AreEqual("Book 2", book2.Name);
            Assert.AreNotSame(book1, book2);
        }

        [TestMethod]
        [TestCategory("Book Test")]
        public void TwoVarsCanReferenceSameObject()
        {
            //arange 
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act

            //assert            
            Assert.AreSame(book1, book2);
            Assert.IsTrue(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
    }
}
