import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { UserRoleEnum } from '../../models/enums/user-role.enum';

@Component({
  selector: 'app-user',
  imports: [RouterLink],
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent {
  firstName: string = '';
  middleName: string = '';
  lastName: string = '';
  username: string = '';
  role: UserRoleEnum = UserRoleEnum.USER;
}