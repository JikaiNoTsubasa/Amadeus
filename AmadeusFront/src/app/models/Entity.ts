export interface Entity{
    id: number;
    name: string;
    createdAt: Date;
    updatedAt: Date;
    deletedAt: Date;
    archivedAt: Date;
    createdById: number;
    createdByName: string;
    updatedById: number;
    updatedByName: string;
    deletedById: number;
    deletedByName: string;
    archivedById: number;
    archivedByName: string;
}