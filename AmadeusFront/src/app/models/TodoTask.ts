import { Entity } from "./Entity";

export interface TodoTask extends Entity {
    description: string | null;
    status: string;
    dueDate: Date | null;
}

export enum TodoTaskStatus {
    TODO = "TODO",
    IN_PROGRESS = "IN_PROGRESS",
    DONE = "DONE",
    DELETED = "DELETED"
}