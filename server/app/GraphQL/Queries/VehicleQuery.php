<?php

namespace App\GraphQL\Queries;
use Illuminate\Support\Facades\DB;
use App\Contract;

class VehicleQuery
{
  /**
   * @param  null  $_
   * @param  array<string, mixed>  $args
   */
  public function getVehicleBrandsInContract($rootValues, array $args): array
  {
    return Contract::join('vehicles', 'vehicles.id', '=', 'contracts.vehicle_id')
      ->select('brand', DB::raw('count(*) as count'))
      ->whereNull('archived')
      ->groupBy('brand')
      ->orderBy('count', 'desc')
      ->get()
      ->toArray();
  }
}
