using LaywerApp.Models;
using LaywerApp.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaywerApp.Services.Interfaces
{
    public interface ILaywerServices
    {
        void CreateRequest(ContactRequest contactRequest);
    }
}
