using System;

namespace Foundation.Classes;

public record EntityBase(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

