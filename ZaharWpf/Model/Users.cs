//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZaharWpf.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public string Photo { get; set; }
    
        public virtual ProgrammingLanguages ProgrammingLanguages { get; set; }
    }
}
