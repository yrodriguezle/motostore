<?php

namespace App\GraphQL\Queries;
use Illuminate\Support\Facades\DB;
use Illuminate\Database\Query\Builder;

class AreaQuery
{
  /**
   * @param  null  $_
   * @param  array<string, mixed>  $args
   */
  public function __invoke($_, array $args)
  {
      // TODO implement the resolver
  }

  public function searchBy($rootValues, array $args)
  {
    $name = isset($args['name']) ? $args['name'] : null;
    $province = isset($args['province']) ? $args['province'] : null;

    $thereIsFirstChoice = DB::table('areas')
      ->where('name', $name)
      ->when($province, function ($query, $province) {
        return $query->where('province', $province);
      })->count();
    if (!empty($thereIsFirstChoice) && $thereIsFirstChoice > 0) {
      return DB::table('areas')
        ->where('name', $name)
        ->when($province, function ($query, $province) {
          return $query->where('province', $province);
        });
    }
    return DB::table('areas')
      ->when($province, function ($query, $province) {
        return $query->where('province', $province);
      })
      ->where('name', 'LIKE', "$name%")
      ->orWhere('name', 'LIKE', "%$name%");
  }
}
