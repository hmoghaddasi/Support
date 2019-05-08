namespace Support.Domain.Model {

    public class AccessPolicy
    {
        public int AccessPolicyId { get; set; }
        public int AccessId { get; set; }
        public int PersonId { get; set; }
        


        public virtual Access Access { get; set; }
        public virtual Person Person { get; set; }

        
    }
}

