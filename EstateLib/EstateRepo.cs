using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateLib
{
    public class EstateRepo
    {
        private int _nextId = 1;

        private List<Estate> _repo;

        public EstateRepo()
        {
            _repo = new List<Estate>()
            {
                new Estate{ Id = _nextId++, Type = "House", Size = 300, Price = 3000000 },
                new Estate{ Id = _nextId++, Type = "Apartment", Size = 80, Price = 800000 },
                new Estate{ Id = _nextId++, Type = "Mansion", Size = 800, Price = 50000000 }
            };
        }

        public List<Estate> GetAllEstates()
        {
            return new List<Estate>(_repo);
        }

        public Estate GetEstateById(int id)
        {
            return _repo.FirstOrDefault(e => e.Id == id);
        }

        public Estate AddEstate(Estate estate)
        {
            estate.Id = _nextId++;
            _repo.Add(estate);
            return estate;
        }

        public Estate? UpdateEstate(int id, Estate estate)
        {
            var existingEstate = GetEstateById(id);
            if (existingEstate != null)
            {
                existingEstate.Type = estate.Type;
                existingEstate.Size = estate.Size;
                existingEstate.Price = estate.Price;
            }
            return existingEstate;
        }

        public Estate? DeleteEstate(int id)
        {
            var estateToDelete = GetEstateById(id);
            if (estateToDelete != null)
            {
                _repo.Remove(estateToDelete);
            }
            return estateToDelete;
        }

    }
}
