if (exists (select name from sysobjects where (name = N'P_Get_Man_Menus') and (type = 'P')))
  drop procedure dbo.P_Get_Man_Menus
go

create procedure [dbo].[P_Get_Man_Menus]
(
	@Man_ID nvarchar(6)
)
as
begin	
	select * from T_Sys_Menu_Group where Mg_Status = 0 order by Mg_Order, Mg_ID
	
	select a.*, b.M_Auth Menu_Auth
  		from T_Sys_Menu a, T_Sys_Role_Menu b, T_Sys_Oper_Role c
  		where a.M_ID = b.M_ID and b.Role_ID = c.Role_ID and a.M_Status = 0 and c.Man_ID = @Man_ID  
  		order by a.Mg_ID, a.M_Level, a.M_Disp, a.M_ID;
  		
  select * from T_Rib_Tab order by Rib_Order
  
  select a.*, b.Rib_Tab_Name from T_Rib_Panel a, T_Rib_Tab b where a.Rib_Tab = b.Rib_Tab order by a.Rib_Tab, a.Rib_Order
  
  select distinct a.* from T_Rib_Button a, T_Sys_Role_Rib b, T_Sys_Oper_Role c
			where a.Rib_Btn = b.Rib_Btn and b.Role_ID = c.Role_ID and c.Man_ID = @Man_ID
end






GO