using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //Lab2 Tests
        #region
        [TestMethod]
        public void Parentheses1()
        {
            Assert.IsTrue(Lab2.Program.IsBalanced("{()}{}"));
        }

        [TestMethod]
        public void Parentheses2()
        {
            Assert.IsTrue(Lab2.Program.IsBalanced("{ int a = new int[ ] ( ( ) ) }"));
        }

        [TestMethod]
        public void Parentheses3()
        {

            Assert.IsFalse(Lab2.Program.IsBalanced("{ [ ] ) ) ( ( "));
        }

        //this one has the right number of corresponding braces but in the wrong order
        [TestMethod]
        public void Parentheses4()
        {
            Assert.IsFalse(Lab2.Program.IsBalanced("{[}]"));
        }

        [TestMethod]
        public void Parentheses5()
        {
            Assert.IsFalse(Lab2.Program.IsBalanced("{"));
        }

        [TestMethod]
        public void Parentheses6()
        {

            Assert.IsFalse(Lab2.Program.IsBalanced("("));
        }

        [TestMethod]
        public void Parentheses7()
        {

            Assert.IsFalse(Lab2.Program.IsBalanced("["));
        }

        [TestMethod]
        public void Parentheses8()
        {

            Assert.IsFalse(Lab2.Program.IsBalanced("}"));
        }

        [TestMethod]
        public void Parentheses9()
        {

            Assert.IsFalse(Lab2.Program.IsBalanced(")"));
        }

        [TestMethod]
        public void Parentheses10()
        {

            Assert.IsFalse(Lab2.Program.IsBalanced("]"));
        }

        [TestMethod]
        public void Parentheses11()
        {
            string testString = @"
using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ListBasedStack<T>
    {
        private readonly LinkedList<T> stack;


        public ListBasedStack() {
            stack = new LinkedList<T>();
        }


        public ListBasedStack(T item) : this() {
            Push(item);
        }


        public ListBasedStack(IEnumerable<T> items)
            : this()
        {
            foreach (var item in items)
            {
                Push(item);
            }
        }


        public int Count
        {
            get
            {
                return
                    stack.Count;
            }
        }



        public void Clear() {
            stack.Clear();
        }


        public bool Contains(T item) {
            stack.Contains(item);
        }


        public T Peek()
        {
            if (stack.First is null)
            {
                throw new InvalidOperationException(""Stack is empty"");
            }

            return stack.First.Value;
        }


        public T Pop()
        {
            if (stack.First is null)
            {
                throw new InvalidOperationException(""Stack is empty"");
            }

            var item = stack.First.Value;
            stack.RemoveFirst();
            return item;
        }


        public void Push(T item) {
            stack.AddFirst(item);
        }
    }
}
";

            Assert.IsTrue(Lab2.Program.IsBalanced(testString));
        }

        [TestMethod]
        public void Parentheses12()
        {
            string testString = "List<int> list = new List<int>();";
            Assert.IsTrue(Lab2.Program.IsBalanced(testString));
        }

        [TestMethod]
        public void Parentheses13()
        {
            string testString = "List<int> list = new List<int();";
            Assert.IsFalse(Lab2.Program.IsBalanced(testString));
        }

        [TestMethod]
        public void Parentheses14()
        {
            string testString = "List<int> list = new List int>();";
            Assert.IsFalse(Lab2.Program.IsBalanced(testString));
        }

        [TestMethod]
        public void Parentheses1withNoBrace()
        {

            Assert.IsTrue(Lab2.Program.IsBalanced("1"));
        }

        [TestMethod]
        public void ParenthesesWithNoBraces()
        {

            Assert.IsTrue(Lab2.Program.IsBalanced("When in the course of Human Events..."));
        }
        #endregion

        //Postfix Tests
        #region
        [TestMethod]
        public void Postfix1()
        {

            Assert.AreEqual(4, Lab2.Program.Evaluate("2 2 +"));
        }

        [TestMethod]
        public void Postfix2()
        {

            Assert.AreEqual(8, Lab2.Program.Evaluate("5 3 +"));
        }

        [TestMethod]
        public void Postfix3()
        {

            Assert.AreEqual(2, Lab2.Program.Evaluate("7 5 -"));
        }

        [TestMethod]
        public void Postfix4()
        {

            Assert.AreEqual(1, Lab2.Program.Evaluate("5 3 1 + -"));
        }

        [TestMethod]
        public void Postfix5()
        {

            Assert.AreEqual(5, Lab2.Program.Evaluate("15 7 1 1 + - / 3 * 2 1 1 + + -"));
        }

        [TestMethod]
        public void Postfix6()
        {

            Assert.AreEqual(45, Lab2.Program.Evaluate("15 7 1 2 + - / 3 * 2 1 1 + + *"));
        }

        [TestMethod]
        public void Postfix7()
        {

            Assert.AreEqual(-3.4, Lab2.Program.Evaluate("16 15 - 7 1 1 + - / 3 * 2 1 1 + + -"));
        }

        [TestMethod]
        public void Postfix8()
        {

            Assert.AreEqual(1.0 / 6.0, Lab2.Program.Evaluate("51 32 + 82 - 6 /"));
        }

        [TestMethod]
        public void Postfix9()
        {

            Assert.AreEqual(2030, Lab2.Program.Evaluate("54 62 + 2 / 35 *"));
        }

        [TestMethod]
        public void Postfix10()
        {

            Assert.AreEqual(23, Lab2.Program.Evaluate("10 2 8 * + 3 -"));
        }
        #endregion

    }
}