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
    
    public partial class Books
    {
        public Books()
        {
            this.Chapters = new HashSet<Chapters>();
        }
    
        public int BookID { get; set; }
        public Nullable<int> LanguageID { get; set; }
    
        public virtual ICollection<Chapters> Chapters { get; set; }
        public virtual ProgrammingLanguages ProgrammingLanguages { get; set; }
    }
}