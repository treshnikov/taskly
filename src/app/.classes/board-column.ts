import { BoardTask } from "./board-task";

export class BoardColumn {
    name: string;
    connectedTo: string[];
    tasksStates: string[];
    tasks: BoardTask[];
}
