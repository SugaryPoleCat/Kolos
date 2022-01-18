using System;

namespace Kolos
{
    interface IWydarzenieCykliczne
    {
        void Przypomnienie(DateTime data, string komunikat);
    }
}
