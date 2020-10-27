<?php

namespace App;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Facades\DB;

use Illuminate\Database\Eloquent\Relations\BelongsToMany;

class Contract extends Model
{
  protected $table = 'contracts';

  public function scopeActiveOrdered(Builder $query): Builder
  {
    return $query->whereNull('archived')->orderBy('contract_date', 'desc');
  }

  public function scopeSearch(Builder $query, $args): Builder
  {
    $search = isset($args['search']) ? $args['search'] : null;
    if ($search !== null) {
      $parts = explode(" ", trim(preg_replace('/\s+/', ' ', str_replace("\n", " ", $search))));
      return $query->where(function($query) use ($parts) {
        foreach ($parts as $part) {
          $query
            ->whereHas('customer', function (Builder $query) use ($part) {
              $query->where(DB::raw("CONCAT(`first_name`, ' ', `last_name`)"), 'like', "%$part%");
            })
            ->orWhereHas('vehicle', function (Builder $query) use ($part) {
              $query->where('plate', 'like', "%$part%");
            });
        }
      });
    }
    return $query;
  }

  public function scopeStatus(Builder $query, $args): Builder
  {
    $status = isset($args['status']) ? $args['status'] : null;
    if ($status !== null) {
      return $query->where(function($query) use ($status) {
        $query->whereHas('vehicle', function (Builder $query) use ($status) {
          $query->where('status', $status);
        });
      });
    }
    return $query;
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function user()
  {
    return $this->belongsTo(User::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function customer()
  {
    return $this->belongsTo(Customer::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function vehicle()
  {
    return $this->belongsTo(Vehicle::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function accessories(): BelongsToMany
  {
    return $this->belongsToMany(Accessory::class, 'contracts_accessories')
      ->using(ContractAccessory::class)
      ->withPivot([
        'user_id',
        'arrived',
        'arrived_date'
      ]);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function services()
  {
    return $this->belongsToMany(Service::class, 'contracts_services');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function payments()
  {
    return $this->belongsToMany(Payment::class, 'payments_contracts');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function acquiredVehicles()
  {
    return $this->belongsToMany(Vehicle::class, 'acquireds_contracts');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasOne
  */
  public function financing()
  {
    return $this->hasOne(Financing::class);
  }
  
  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function complete()
  {
    return $this->belongsToMany(Complete::class, 'contract_complete');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasMany
  */
  public function documents()
  {
    return $this->hasMany(ContractDocument::class);
  }
}