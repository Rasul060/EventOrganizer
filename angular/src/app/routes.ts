import { Routes } from "@angular/router";
import { AuthComponent } from "./auth/auth.component";
import { EventComponent } from "./event/event.component";
import { OrganizerComponent } from "./organizer/organizer.component";

export const appRoutes : Routes = [
    {path: "event", component: EventComponent},
    {path: "organizer", component: OrganizerComponent},
    {path: "login", component: AuthComponent},
    {path: "**", redirectTo: "login", pathMatch: "full"}
];