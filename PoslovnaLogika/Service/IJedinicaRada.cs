using System;

namespace PoslovnaLogika.Service
{
    interface IJedinicaRada //: IDisposable
    {
        IMarkaRepozitorij Marka { get; }

        int Spremi();
    }
}