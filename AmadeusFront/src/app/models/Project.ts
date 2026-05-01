import { Customer } from "./Customer";
import { Entity } from "./Entity";
import { User } from "./User";

export interface Project extends Entity {
    code: string | null;
    description?: string;
    summary?: string;
    status: ProjectStatus;
    owner: User | null;
    customer: Customer | null;
}

export enum ProjectStatus {
    NEW = 'NEW',
    IN_PROGRESS = 'IN_PROGRESS',
    COMPLETED = 'COMPLETED',
    CANCELLED = 'CANCELLED',
    DELETED = 'DELETED',
    ARCHIVED = 'ARCHIVED'
}