import { User } from "./User";

export interface Entity{
    id: number;
    name: string;
    createdAt: Date;
    updatedAt: Date;
    deletedAt: Date;
    archivedAt: Date;
    createdBy: User | null;
    updatedBy: User | null;
    deletedBy: User | null;
    archivedBy: User | null;
}