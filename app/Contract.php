<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Contract extends Model
{
  protected $table = 'contracts';

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
  public function accessories()
  {
    return $this->belongsToMany(Accessory::class, 'contracts_accessories');
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