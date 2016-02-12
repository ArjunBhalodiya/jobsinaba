using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using JobsInABA.DTOs;
using JobsInABA.DTOs.Assemblers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsInABA.BL
{
    public class CountryBL
    {
        CountriesRepo _CountryRepos;

        private CountriesRepo oCountryRepos
        {
            get
            {
                if (_CountryRepos == null) _CountryRepos = new CountriesRepo();
                return _CountryRepos;
            }
        }

        public CountryDTO Get(int CountryID)
        {
            CountryDTO oCountryDTO = null;
            if (CountryID > 0)
            {
                Country oCountry = oCountryRepos.GetCountry(CountryID);
            }

            return oCountryDTO;
        }

        public Country Create(Country oCountry)
        {
            if (oCountry != null)
            {
                return oCountryRepos.CreateCountry(oCountry);
            }

            return null;
        }

        public CountryDTO Update(CountryDTO oCountryDTO)
        {
            CountryDTO returnUserMap = null;
            if (oCountryDTO != null && oCountryDTO.CountryID > 0)
            {
                oCountryRepos.UpdateCountry(0, CountryAssembler.ToEntity(oCountryDTO));
                returnUserMap = oCountryDTO;
            }

            return returnUserMap;
        }

        public bool Delete(int CountryID)
        {
            Boolean isDeleted = false;

            if (CountryID > 0)
            {
                try
                {
                    oCountryRepos.DeleteCountry(CountryID);
                }
                catch
                {
                    return false;
                }
            }
            return isDeleted;
        }
    }
}