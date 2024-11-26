namespace Contracts.Roles
{
    /// <summary>
    /// Транспортная модель роли
    /// </summary>
    public sealed class RoleDto
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }
    }
}
