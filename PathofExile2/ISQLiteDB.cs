using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PathofExile2
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
