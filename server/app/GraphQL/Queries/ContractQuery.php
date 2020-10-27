<?php

namespace App\GraphQL\Queries;

use Illuminate\Support\Facades\DB;
use Illuminate\Database\Query\Builder;

use GraphQL\Type\Definition\ResolveInfo;
use Nuwave\Lighthouse\Support\Contracts\GraphQLContext;

class ContractQuery
{
  /**
   * @param  null  $_
   * @param  array<string, mixed>  $args
   */
  // public function __invoke($_, array $args)
  // {
  //   // TODO implement the resolver
  // }

  public function getActiveContracts($rootValues, array $args, GraphQLContext $context, ResolveInfo $resolveInfo): Builder
  {
    // $search = isset($args['search']) ? $args['search'] : null;
    // $status = isset($args['status']) ? $args['status'] : null;
    // $brands = isset($args['brands']) ? $args['brands'] : null;
    // $userIds = isset($args['userIds']) ? $args['userIds'] : null;

    return DB::table('contracts')->whereNull('archived');

    // return DB::table('contracts')
    //   ->whereNull('archived')
    //   ->when($search, function ($subQuery, $search) {
    //     $parts = explode(" ", trim(preg_replace('/\s+/', ' ', str_replace("\n", " ", $search))));
    //     return $subQuery
    //       ->where(function($subQuery) use ($parts) {
    //         foreach ($parts as $part) {
    //           $subQuery->whereHas('customer', function (Builder $subQuery) use ($part) {
    //             $subQuery->where(DB::raw("CONCAT(`first_name`, ' ', `last_name`)"), 'like', "%$part%");
    //           })
    //           ->orWhereHas('vehicle', function (Builder $subQuery) use ($part) {
    //             $subQuery->where('plate', 'like', "%$part%");
    //           });
    //         }
    //       });
    //   })
    //   ->when($brands, function ($subQuery, $brands) {
    //     return $subQuery
    //       ->where(function($subQuery) use ($brands) {
    //         $subQuery->whereHas('vehicle', function (Builder $subQuery) use ($brands) {
    //           $subQuery->whereIn('brand', $brands);
    //         });
    //     });
    //   })
    //   ->when($status, function ($subQuery, $status) {
    //     return $subQuery
    //       ->where(function($subQuery) use ($status) {
    //         $subQuery->whereHas('vehicle', function (Builder $subQuery) use ($status) {
    //           $subQuery->where('status', $status);
    //         });
    //     });
    //   })
    //   ->when($userIds, function ($subQuery, $userIds) {
    //     return $subQuery
    //       ->where(function($subQuery) use ($userIds) {
    //         $subQuery->whereHas('user', function (Builder $subQuery) use ($userIds) {
    //           $subQuery->whereIn('id', $userIds);
    //         });
    //     });
    //   });
  }
}
