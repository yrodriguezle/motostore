<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class ContractDocument extends Model
{
  protected $table = 'contract_documents';

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
  public function contracts()
  {
    return $this->belongsTo(Contract::class);
  }
}