-- Write your own SQL object definition here, and it'll be included in your package.
Alter Table Resources Add Constraint UniqueConstraint UNIQUE (Source, EntityType, SourceEntityId)