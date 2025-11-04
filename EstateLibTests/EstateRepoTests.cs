using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstateLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateLib.Tests
{
    [TestClass()]
    public class EstateRepoTests
    {
        private EstateRepo _repo;

        [TestInitialize]
        public void TestInitialize()
        {
            _repo = new EstateRepo();
        }

        [TestMethod()]
        public void GetAllEstatesTest()
        {
            Assert.AreEqual(3, _repo.GetAllEstates().Count);
        }

        [TestMethod()]
        public void GetEstateByIdTest()
        {
            Estate expectedEstate = new Estate("House", 300, 3000000);
            Estate actualEstate = _repo.GetEstateById(1);

            Assert.AreEqual(expectedEstate.Type, actualEstate.Type);
            Assert.AreEqual(expectedEstate.Size, actualEstate.Size);
            Assert.AreEqual(expectedEstate.Price, actualEstate.Price);
        }

        [TestMethod()]
        public void AddEstateTest()
        {
            Estate estate = new Estate("Test", 1, 1);
            Estate addedEstate = _repo.AddEstate(estate);

            Assert.AreEqual(estate, addedEstate);
        }

        [TestMethod()]
        public void UpdateEstateTest()
        {
            Estate values = new Estate("Updated", 2, 2);

            Estate? updatedEstate = _repo.UpdateEstate(1, values);

            Assert.AreEqual(values.Type, updatedEstate?.Type);
            Assert.AreEqual(values.Size, updatedEstate?.Size);
            Assert.AreEqual(values.Price, updatedEstate?.Price);
        }

        [TestMethod()]
        public void DeleteEstateTest()
        {
            Estate? deletedEstate = _repo.DeleteEstate(1);
            Assert.AreEqual(2, _repo.GetAllEstates().Count);
            Assert.IsNull(_repo.GetEstateById(1));
        }
    }
}