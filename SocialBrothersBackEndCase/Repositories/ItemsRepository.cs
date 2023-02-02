using System;
using System.Collections.Generic;
using SocialBrothersBackEndCase.Models;


namespace SocialBrothersBackEndCase.Repositories
{
    
        public interface ItemsRepository

        {
        void  GetDataList(DataList item);
        IEnumerable<DataList> GetDataLists();

        void createItem(DataList item);

        void UpdateItem(DataList item);

        void DeleteItem(Guid id);
        }

   
    }

