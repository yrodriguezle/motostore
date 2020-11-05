<?php

namespace App\GraphQL\Queries;

use Illuminate\Database\Query\Builder;
use Illuminate\Support\Facades\Auth;
use \Illuminate\Support\Facades\DB;
use Illuminate\Support\Arr;
use Illuminate\Support\Collection;

class MenuQuery
{
  /**
   * @param  null  $_
   * @param  array<string, mixed>  $args
   */
  public function __invoke($_, array $args)
  {
    $user = Auth::guard('api')->user();
    $roleId = $user->role_id;
    $permissionsArray = \App\Permission::select(DB::raw('SUBSTRING(permissions.key, 8) as slug'))
      ->join('permission_role', 'permissions.id', '=', 'permission_role.permission_id')
      ->where('permission_role.role_id', $roleId)
      ->where('permissions.key', 'like', "%browse%")
      ->pluck('slug')
      ->all();
    $url = DB::raw('SUBSTRING(menu_items.url, 2)');
    $children = \App\Menu::whereIn($url, $permissionsArray)
      ->get();
    $parentIds = Arr::pluck($children, 'parent_id');
    $parents = \App\Menu::whereIn('id', $parentIds)
      ->get();
    
    return Arr::collapse([$parents, $children]);
  }
}
