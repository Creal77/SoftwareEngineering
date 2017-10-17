using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    /// <summary>
    /// Description résumée pour GameTest
    /// </summary>
    [TestClass]
    public class GameTest
    {
        Game g;

        [TestInitialize]
        public void SetUp()
        {
            g = new Game(5, 5);
        }
        [TestMethod]
        public void GoEast()
        {
            g.PutPlayerInRoom(1); // étant donné ...
            g.Move(Direction.EAST); // lorsque ...
            Assert.AreEqual(2, g.GetPlayerRoom()); // alors ...
        }
        public void GoWestTwice()
        {
            g.PutPlayerInRoom(1);
            g.Move(Direction.WEST);
            g.Move(Direction.WEST);
            Assert.AreEqual(4, g.GetPlayerRoom());
        }
    }
}
