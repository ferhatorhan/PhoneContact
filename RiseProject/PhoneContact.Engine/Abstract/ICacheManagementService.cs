using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Engine.Abstract
{
    public interface ICacheManagementService
    {
        Task<bool> Clear();
    }
}
