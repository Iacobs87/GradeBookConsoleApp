﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBook.Test
{

    public delegate string WriteLogDelegate(string logMessage);

    [TestClass]
    public class BookTests
    {

   
        [TestMethod]
        [TestCategory("Book Test")]
        public void BookCalculatesStatistics()
        {
            //arange 

            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.AreEqual(85.6, result.Average, 1);
            Assert.AreEqual(90.5, result.High, 1);
            Assert.AreEqual(77.3, result.Low, 1);
            Assert.AreEqual('B', result.Letter);

        }
    }
}
