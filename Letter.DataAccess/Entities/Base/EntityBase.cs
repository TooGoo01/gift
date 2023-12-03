﻿namespace Letter.DataAccess.Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public int RegUserId { get; set; }
        public DateTime RegDate { get; set; }
        public int? EditUserId { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
