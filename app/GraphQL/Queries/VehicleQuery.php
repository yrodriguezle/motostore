<?php

namespace App\GraphQL\Queries;
use Illuminate\Support\Facades\DB;
use Illuminate\Database\Query\Builder;

class VehicleQuery
{
  /**
   * @param  null  $_
   * @param  array<string, mixed>  $args
   */
  // public function __invoke($_, array $args)
  // {
  //     // TODO implement the resolver
  // }

  public function getVehicles($rootValues, array $args): Builder
  {
    $search = isset($args['search']) ? $args['search'] : null;
    $new = isset($args['new']) ? $args['new'] : null;
    $used = isset($args['used']) ? $args['used'] : null;
    $rented = isset($args['rented']) ? $args['rented'] : null;
    $noPayed = isset($args['noPayed']) ? $args['noPayed'] : null;

    if ($noPayed === true) {
      return DB::table('vehicles')
            ->where('status', 'new')
            ->whereNull('invoice_payment_date');
    }
    return DB::table('vehicles')
      ->whereNull('out_customer_id')
      ->where(function ($query) use ($new, $used, $rented) {
        $query->when($new, function ($query, $new) {
          return $query->orWhere('status', 'new');
        })
          ->when($used, function ($query, $used) {
            return $query->orWhere('status', 'used');
          })
          ->when($rented, function ($query, $rented) {
            return $query->orWhere('status', 'rented');
          });
      });
  }
}
