namespace Core.Entities.Concrete
{
    class UserOperationClaim :IEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
